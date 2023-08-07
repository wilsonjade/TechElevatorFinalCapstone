<template>
  <section>
    <h1>Plants</h1>
    <section class="container">
      <plant-detail v-for="plant in plants" v-bind:key="plant.id" v-bind:plant="plant" />
    </section>
  </section>
</template>

<script>
import PlantDetail from "./PlantDetail.vue"
export default {
  components: { PlantDetail },
  name: "ListPlants",
  data () {
      return {
        
      }
  },

  computed: {
    plants() {
      return this.$store.state.plants;
    }
  }

};
</script>

<style>
</style>