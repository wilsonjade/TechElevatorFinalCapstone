<template>
  <div>
     
  <section class="garden-container">
      
      <plant-garden-card v-for="plant in myPlants" v-bind:key="plant.plantId" v-bind:thisPlant="plant"     />
    
  </section>
  </div>
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
        myPlants : []
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
#gardenheadline{
  display: block;
  text-align: center;
  margin: auto;
}
.garden-container{
  display: flex;
  flex-direction: row;
  justify-content: center;
  flex-wrap: wrap;
  align-content: flex-start;
  
}
</style>