<template>
  <section class="rating-detail card">
    <h1>{{ item.title }}</h1>
    <p>{{ item.rating }}</p>
    <p>{{ item.review }}</p>

    <button
      v-if="isAdmin"
      v-on:click="
        $router.push({ name: 'ratingAdmin', params: { id: item.ratingId } })
      "
    >
      Edit Rating
    </button>
    <button v-if="isAdmin" v-on:click="deleteThisRating()">
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
    getThisRating(){
      RatingService.getRatingBySellerId(this.$route.params.sellerId)
      .then( (response) => {
        this.rating = response.data;
      });
    },
  },
  created() {
    this.getThisRating();
  },
};
</script>

<style>
</style>