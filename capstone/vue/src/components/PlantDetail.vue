<template>
  <section class="plant card">
    <h1 class="headline">Common name: {{ plant.commonName }}</h1>
    <p>Id: {{ plant.plantId }}</p>
    <p>Kingdom: {{ plant.kingdom }}</p>
    <p>Order: {{ plant.order }}</p>
    <p>Family: {{ plant.family }}</p>
    <p>Subfamily: {{ plant.subfamily }}</p>
    <p>Genus: {{ plant.genus }}</p>
    <p>Species: {{ plant.species }}</p>
    <p>Description: {{ plant.description }}</p>
    <section>
      <img v-bind:src="plant.imgUrl" alt="a generic plant image"/>
    </section>
    <section>
      <h2>Description and details</h2>
      <router-link v-bind:to="{name: 'sellersByPlant'}">Find Retailers</router-link>
    </section>
  </section>

</template>

<script>

import plantService from "../services/PlantService.js"

export default {
  name: "plant",
  

  methods: {
    getThisPlant(){
      plantService.getPlantById(this.$route.params.plantId)
      .then((response)=>{
        console.log(response)
        this.plant = response.data})
    },
  },

  data(){
    return {
      plant: {}
    }
  },

  created(){
  //  console.log("Reached created")
    this.getThisPlant();

  }
};
</script>

<style>
</style>