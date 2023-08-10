<template>
  <section>
      <h1>RatingsList.vue</h1>
      <rating-detail v-for="rating in filteredRatings" v-bind:key="rating.ratingId" v-bind:item="rating" />


  </section>
</template>

<script>
import RatingDetail from './RatingDetail.vue'
import RatingService from '../services/RatingService.js'

export default {
    name: "listRatings",
    props: ["item"],
  components: { RatingDetail },
  data() {
      return {
          filteredRatingsBySeller: [],
      }
  },
  methods: {},
  computed: {
      ratings() {
          return this.$store.state.ratings;
      },
      filteredRatings() {
          if(this.filteredRatingsBySeller.length > 0) {
              return this.$store.state.ratings.filter( (rating) => {
                  return this.filteredRatingsBySeller.includes(rating.SellerId)})
          } 
          else {return this.$store.state.ratings}
      }
  },
  created() {
      if(this.$route.params.sellerId) {
          RatingService.getRatingBySellerId(this.$route.params.plantId)
          .then( response => {
              this.filteredRatingsBySeller = response.data;
          })
      }
  }

}
</script>

<style>

</style>