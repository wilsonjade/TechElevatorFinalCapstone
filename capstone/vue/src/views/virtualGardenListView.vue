<template>
  <div id="gardenlistcontainer">
      <div class="gardenlistcard card" v-on:click="visitGarden" v-for="garden in gardens" v-bind:key="garden.userId">
          
        <div>  {{garden.firstName}}'s Garden</div>
          Level {{garden.expertiseLevel}} Gardener
          Located in Zone : {{garden.region}}
         {{garden.firstName}} has {{garden.plantCount}} plants in their garden
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
        }
        )
        //call user list
        //add user name/region/etc
        //add plant count
    }
}
</script>

<style>
.gardenlistcontainer{
    display: flex;
  flex-direction: row;
  justify-content: center;
  flex-wrap: wrap;
  align-content: flex-start;
}
.gardenlistcard{
    display: flex;
    border-radius: 20px;
    border-style: solid;
    border-color: black;
    width: 30%;
    margin: 25px;
    padding: 10px;
}
</style>