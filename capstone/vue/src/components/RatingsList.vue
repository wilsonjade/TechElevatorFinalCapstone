<template>
  <section>
    <rating-detail
      v-for="rating in ratings"
      v-bind:key="rating.ratingId"
      v-bind:item="rating"
    />
  </section>
</template>

<script>
import RatingDetail from "./RatingDetail.vue";

export default {
  name: "listRatings",
  props: ["item"],
  components: { RatingDetail },
  data() {
    return {
      sellerId: this.$route.params.sellerId,
    };
  },
  methods: {},
  computed: {
    ratings() {
      return this.$store.state.ratings;
    },
  },
  created() {
    this.$store.commit("LOAD_RATINGS", this.sellerId);
  },
};
</script>

<style>
</style>