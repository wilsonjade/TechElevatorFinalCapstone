<template>
  <div class="plantcardcontainer" v-on:hover="showTips()">
      <h1> {{thisPlant.commonName}}</h1>
      <img id="cardimg" class="cardimg" v-bind:src="thisPlant.imgUrl" />
      <p> {{thisPlant.species}}</p>
      <button v-on:click="remove()" id="remove">Remove from My Garden</button>
      <div class="tipcontainer">
          <span> Care and Feeding </span>
          <div class="tip sun" ><img class="icon" src="../assets/sunicon.png" /> Sun: {{thisPlant.sun}}</div>
           <div class="tip water" ><img class="icon" src="../assets/watericon.png" />Water: {{thisPlant.water}}</div>
            <div class="tip fertilizer" >Fertilizer: {{thisPlant.fertilizer}}</div>
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
    font-size: 95%;
    text-align: center;
}
.plantcardcontainer:hover>.tipcontainer{
    display: flex;
    flex-wrap: wrap;
    flex-direction: row;
  justify-items: center;
    background-color: chartreuse;
}
.tipcontainer>span{
    margin-left: auto;
    margin-right: auto;
}
.tip{
    display: block;
    width: 100%;
    font-size: 75%;
    padding: 5px;
    margin: 5px 0 5px 0;
    border-style: solid;
    border-radius: 10px;
}
.icon{width: 5%;
margin-right: 2%;}
.sun{
    background-color: yellow;
}
.water{
    background-color: gray;
}
.fertilizer{
    background-color: goldenrod;
}
#cardimg{
    margin-left:10%;
    margin-right:10%;
    justify-items: center;
    width: 80%;
    height: 100px;
    margin-top: 5%;
    object-fit: cover;
    border-radius: 0;
}
.plantcardcontainer{
    width: 20%;
    font-size: larger;
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