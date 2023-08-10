<template>
  <div class="plantcardcontainer">
      <h1> {{thisPlant.commonName}}</h1>
      <img id="cardimg" class="cardimg" v-bind:src="thisPlant.imgUrl" />
      <p> {{thisPlant.species}}</p>
      <button v-on:click="remove()" id="remove">Remove from My Garden</button>
  </div>
</template>

<script>
import PlantService from '../services/PlantService'
export default {
    data(){
        return {

        }
    },
    props: ["thisPlant"]
    ,
    methods: {
        remove(){
            PlantService.removeFromGarden({userId: this.$store.state.user.userId, plantId: this.thisPlant.plantId}).then(
                response=> {
                    if(response.status == 200){
                        this.$router.go(0); //refresh page
                    }
                }
            )
        }
    }
}
</script>

<style>

#cardimg{
    margin-left:10%;
    margin-right:10%;
    justify-items: center;
    width: 80%;
    height: 25%;
    margin-top: 5%;
    object-fit: cover;
    border-radius: 0;
}
.plantcardcontainer{
    width: 20%;
    margin-left: 20px;
    margin-right: 20px;
    background-color:lightgrey;
}
#remove{
    /* how to push this to the bottom?? */
}
</style>