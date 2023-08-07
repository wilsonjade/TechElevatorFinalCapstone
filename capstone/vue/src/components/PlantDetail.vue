<template>
  <section class="plant">
    <p>Id: {{ plant.plantId }}</p>
    <p>Kingdom: {{ plant.kingdom }}</p>
    <p>Order: {{ plant.order }}</p>
    <p>Family: {{ plant.family }}</p>
    <p>Subfamily: {{ plant.subfamily }}</p>
    <p>Genus: {{ plant.genus }}</p>
    <p>Species: {{ plant.species }}</p>
    <p>Common name: {{ plant.commonName }}</p>
    <p>Description: {{ plant.description }}</p>
  </section>
</template>

<script>

import plantService from "../services/PlantService.js"

export default {
  name: "plant",
  

  methods: {
    getPlantById(plantId){
      plantService.getPlantById(plantId)

    }
  },

  data(){
    return {
      plant: {}
    }
  },

  created(){
    console.log("Reached created")
    console.log(this.$route.params.plantId)
    console.log(this.getPlantById(this.$route.params.plantId))
    this.getPlantById(this.$route.params.plantId).then(response => {
      this.plant = response.data
    })
    
    

  }
};
</script>

<style>
</style>