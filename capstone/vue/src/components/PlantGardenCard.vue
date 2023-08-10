<template>
  <section class="plantcardcontainer">
      <h1> {{thisPlant.commonName}}</h1>
      <img class="cardimg" v-bind:src="thisPlant.imgUrl" />
      <p> {{thisPlant.species}}</p>
      <p> {{thisPlant}}</p>

  </section>
</template>

<script>
export default {
    data(){
        return {

        }
    },
    props: ["thisPlant"]
}
</script>

<style>

.cardimg{
    margin: auto;
    
    
}
.plantcardcontainer{
    margin: auto;
    width: 25%;
    height: auto;
    background-color:blueviolet;
}
</style>