<template>
  <form v-on:submit.prevent="addRating" class="card">
    <h1>New review form</h1>
      <div>
      <label for="title">Title: </label>
      <input type="text" name="title" id="rating-title" v-model="newRating.title">
      </div>
      <div>
      <label for="rating">Rating: </label>
      <input type="number" min='1' max='5' name="rating" id="rating-rating" v-model.number="newRating.rating">
      </div>
      <div>
      <label for="review">Review: </label>
      <textarea rows="4" cols="50" name="review" id="rating-review" v-model="newRating.review" />
      </div>


      <button type="submit">Save Rating</button>
  </form>
</template>

<script>
import RatingService from '../services/RatingService';
export default {
    name: 'RatingsAdmin',
    data() {
        return{
            newRating: {
                ratingId: 0,
                userId: this.$store.state.user.userId,
                sellerId: parseInt(this.$route.params.sellerId),
                title: '',
                rating: 0,
                review: '',
            },
        }
    },
    computed: {
    },
    methods: {
        addRating() {
          console.log("reached ratingsAdmin --> addRating()")
            RatingService.createRating(parseInt(this.$route.params.sellerId), this.newRating)
            .then( () => {
                this.$store.commit("LOAD_RATINGS");
                this.$router.push({name: "ratingsBySeller"});
            })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            console.log("Error updating ratings: ", error.response.status);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            console.log("Error updating ratings: unable to communicate to server");
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            console.log("Error updating ratings: error making request");
          }
        });

        }
    }

}
</script>

<style scoped>
.card {
  max-width: 450px;
}
</style>