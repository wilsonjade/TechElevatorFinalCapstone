<template>
  <div class="plantcardcontainer" v-on:hover="showTips()">
      <h1> {{thisPlant.commonName}}</h1>
      <img id="cardimg" class="cardimg" v-bind:src="thisPlant.imgUrl" />
      <p> {{thisPlant.species}}</p>
      <button v-on:click="remove()" id="remove">Remove from My Garden</button>
      <div class="tipcontainer">
          <span class="tip" v-for="tip in tips" v-bind:key="tip" >{{tip}}</span>
     </div>
  </div>
</template>

<script>
import PlantService from '../services/PlantService'
export default {
    data(){
        return {
            tips: ['tip1', 'tip2']
        }
    },
    props: ["thisPlant"]
    ,
    methods: {
        remove(){
            PlantService.removeFromGarden({plantId: this.thisPlant.plantId, userId: this.$store.state.user.userId}).then(
                response=> {
                    if(response.status == 200){
                        this.$router.go(0); //refresh page
                    }
                }
            )
        },
        showTips(){

        }
    }
}
</script>

<style>
.plantcardcontainer>.tipcontainer{
    display: none;
    margin-top: 10px;
}
.plantcardcontainer:hover>.tipcontainer{
    display: flex;
    background-color: chartreuse;
}
.tip{
    border-style: solid;
    border-radius: 10px;
}
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
    padding: 15px;
    background-color:lightgrey;
    border-style: solid;
    border-radius: 30px;
    
}
#remove{
    /* how to push this to the bottom?? */
}
</style>