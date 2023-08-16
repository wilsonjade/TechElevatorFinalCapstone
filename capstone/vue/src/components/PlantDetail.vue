<template>
  <section class="plantCard card">
    <h1 class="headline">Common name: {{ plant.commonName }}</h1>
    <div class="card" >
    <p>Id: {{ plant.plantId }}</p>
    <p>Kingdom: {{ plant.kingdom }}</p>
    <p>Order: {{ plant.order }}</p>
    <p>Family: {{ plant.family }}</p>
    <p>Subfamily: {{ plant.subfamily }}</p>
    <p>Genus: {{ plant.genus }}</p>
    <p>Species: {{ plant.species }}</p>
    <p>Description: {{ plant.description }}</p>


    </div>
    <section>
      <p><router-link :to="{ name: 'taskAdmin' }">Edit and add task.</router-link></p>
    </section>
    <section>
      <p><router-link :to="{ name: 'taskAdminDelete' }">Delete task.</router-link></p>
    </section>
    <section>
      <img v-bind:src="plant.imgUrl" alt="a generic plant image"/>
    </section>
    <section>
      <button v-on:click="addToGarden()" > Add to My Virtual Garden </button>
      <button><router-link v-bind:to="{name: 'sellersByPlant'}">Find Retailers</router-link></button>
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
    addToGarden(){
      
      plantService.addToGarden({plantId: this.plant.plantId, userId: this.$store.state.user.userId}).then(response=>{
        if(response.status == 200){
        this.$router.push({name: "virtualGardenView"}) }
      }
      ).catch(error=> {
        console.log(error.message)
        this.$router.push({name: "virtualGardenView"})
      
      })
      
    }
  },

  data(){
    return {
      plant: {}
    }
  },

  created(){
    this.getThisPlant();

  }
};
</script>

<style>
.plantCard{
  margin: auto;
}
</style>