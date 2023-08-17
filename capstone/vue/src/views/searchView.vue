<template>
  <section>
      <h3>Welcome to the Search Page</h3>
      <h1>While here, you can search plants by common name, family, species, and genus.</h1>
    
  <form v-on:submit.prevent="searchPlantByCommonName()">
    <div class="searchbar"> 
      <label>Common Name:</label>
    <input v-model="search.commonName" type="text" placeholder="Search plants by name..">

   <label>Family:</label>
    <input v-model="search.family" type="text" placeholder="Search plants by family..">

<label>Species</label>
    <input v-model="search.species" type="text" placeholder="Search plants by species..">

    <label>Genus:</label>
    <input v-model="search.genus" type="text" placeholder="Search plants by genus..">
   <input type="submit" value="Search" >
   
   </div> 
   </form>

     <h3 v-for="plant in plants" v-bind:key="plant.id">{{plant.commonName}}</h3>
     <button v-for="plant in plants" v-bind:key="plant.id"><router-link v-bind:to="{name:'plantDetail', params:{plantId:plant.plantId}}" >Details</router-link></button>
    
     <table>
       <thead>
         <th>Common Name</th><th>Family</th><th>Genus</th><th>Species</th><th>Description</th> <th>View Details</th>
         </thead>
         <tbody>
           <tr v-for="plant in plants" v-bind:key="plant.id">
             <td>{{plant.commonName}}</td><td>{{plant.family}}</td><td>{{plant.genus}}</td><td>{{plant.species}}</td><td>{{plant.description}}</td><td><button ><router-link v-bind:to="{name:'plantDetail', params:{plantId:plant.plantId}}" >Details</router-link></button></td>
           </tr>
         </tbody>
      </table>
   
   
  </section>

</template>

<script>

//return a simple description(name etc) and a link to that specific plant detail page 
import plantService from "../services/PlantService.js"

export default {
  name: "search",
  components: {  },
  data() {
    return {search: {commonName: "",
    family: "",
    species: "",
    genus:""
    },
    plants: []};
  },
  methods: {
    searchPlantByCommonName(){
      plantService.getPlantByCommonName(this.search)
      .then((response)=>{
        console.log(response)
        this.plants = response.data
        // this.plants.forEach(e=> e.description = e.description.substr(0,15)) shorten description?
        })
    },
  }

}
</script>






<style>
.searchbar input[type=text] {
  padding: 10px;
  border-width: medium;
  border-color: olivedrab;
  margin-top: 10px;
  margin-right: 30px;
  font-size: 20px;
}

/* Change the color of links on hover */
/* .searchbar a:hover {
  background-color: #ddd;
  color: black;
} */

</style>