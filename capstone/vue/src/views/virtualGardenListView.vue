<template>
  <div id="gardenlistcontainer">
      <div class="gardenlistcard card" v-on:click="visitGarden" v-for="garden in gardens" v-bind:key="garden.userId">
          
        <div>  {{garden.firstName}}'s Garden</div>
        <section>  Level {{garden.expertiseLevel}} Gardener</section>
         <section>   Located in Zone : {{garden.region}}</section>
        <section>   {{garden.firstName}} has {{garden.plantCount}} plants in their garden</section>
      <button><router-link v-bind:to="{name: 'virtualGardenView', params: {user: garden.userId}}"> Visit Garden </router-link></button>
      </div>

  </div>
</template>

<script>
import PlantService from '../services/PlantService'
export default {
    name: 'virtualGardenListView'
    ,
    data(){
        return {
            gardens: []
        }
    }
    ,
    methods: {
        visitGarden(){
            this.$router.push(
                {name: 'virtualGardenView', 
                params: {user: this.garden.userId}
                })
        }
    }
    ,
    created(){
        
        PlantService.getAllGardens().then( response =>{
            this.gardens = response.data
            this.gardens = this.gardens.filter(g=> g.userId != this.$store.state.user.userId) //filter out user's own garden
        }
        )
    }
}
</script>

<style>
/* .gardenlistcontainer{
    display: flex;
  flex-direction: row;
  justify-content: center;
  flex-wrap: wrap;
  align-content: flex-start;
}*/
.gardenlistcard{
   width: fit-content;
} 
</style>