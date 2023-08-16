<template>
  <div>
     
  <section class="garden-container">
      
      <plant-garden-card v-for="plant in myPlants" v-bind:key="plant.plantId" v-bind:thisPlant="plant" v-bind:isMine="isMyGarden"    />
    
  </section>
    <router-link v-bind:to="{name: 'virtualGardenListView'}"> Explore Community Gardens </router-link>
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
    computed: {
      isMyGarden(){
        const isMine = this.$route.params.user == this.$store.state.user.userId;
        return isMine;
      }
    },
    created(){
      //populate myPlants
      PlantService.listGardenPlants(this.$route.params.user).then(response=>
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