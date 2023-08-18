<template>
  <section class="rating-detail card">
    <p class="card-header">User Rating for {{item.sellerName}}</p>
    <p>Title: {{ item.title }}</p>
    <p>Rating: {{ item.rating }}/5</p>
    <p>Retailer: {{ item.sellerName }}</p>
    <p>Review: {{ item.review }}</p>
    <p>User: {{ item.firstName }}</p>
    
      <button v-if="isAdmin"  v-on:click="deleteThisRating()">
        Delete Rating
      </button>
    
  </section>
</template>

<script>
import RatingService from "../services/RatingService";

export default {
  name: "ratingDetail",
  props: ["item"],
  components: {},
  data() {
    return {
      isAdmin: false,
      rating: {},
    };
  },
  methods: {
    deleteThisRating() {
      let wasSuccess = false;
      let errorMsg = "";
      RatingService.deleteRating(this.item.ratingId)
        .then((response) => {
          wasSuccess = response.status == 200;
          alert(
            wasSuccess
              ? "Rating Deleted"
              : "Rating deletion was unsuccessful, please try again."
          );
          this.$router.go(0);
        })

        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            errorMsg = `Error deleting seller: ${error.response.status}`;
            alert(errorMsg);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            errorMsg = "Error deleting seller: unable to communicate to server";
            alert(errorMsg);
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            errorMsg = "Error deleting seller: error making request";
            alert(errorMsg);
          }
        });
    },
  },
  created() {    
     this.isAdmin = this.$store.state.user.role == "admin";
  },
};
</script>

<style scoped>
.card {
  max-width: 60%;
  margin: 1rem auto;
}
</style>