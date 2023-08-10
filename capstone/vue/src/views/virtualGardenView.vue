<template>
  <section>
    <section class="garden-container">

      <h1>this is the virtualGardenView</h1>
      <p> list of owned plants here</p>
      <plant-garden-card v-for="plant in myPlants" v-bind:key="plant.plantId" v-bind:thisPlant="plant"     />
    </section>
  </section>
</template>

<script>
import PlantGardenCard from '../components/PlantGardenCard.vue'
import PlantService from '../services/PlantService'
export default {
  components: { PlantGardenCard },
    name: "VirtualGardenView"
    ,
    data(){
      return {
        myPlants : ['test1','test2']
      }
    },
    created(){
      //populate myPlants
      PlantService.listGardenPlants(this.$store.state.user.userId).then(response=>
      this.myPlants = response.data
      )
    }
}
</script>

<style>
.garden-container{
  display: flex;
  flex-direction: row;
  justify-content: center;
}
</style>