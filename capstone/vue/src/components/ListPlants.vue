<template>
  <section>
    <section class="container">
      <plant-detail v-for="plant in plants" v-bind:key="plant.plantId" v-bind:plant="plant" />
    </section>
  </section>
</template>

<script>
import PlantDetail from "./PlantDetail.vue"


export default {
  name: "ListPlants",
  components: { PlantDetail },
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