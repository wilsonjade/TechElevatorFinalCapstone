<template>
  <div class="my-virtual-garden-view">
    <section class="header">
      <h1 id="gardentitle">{{ name }}'s Garden</h1>
    </section>    
    <section id="gardencontainer" class="flex-container">
      <plant-garden-card
        v-for="plant in myPlants"
        v-bind:key="plant.plantId"
        v-bind:thisPlant="plant"
        v-bind:isMine="isMyGarden"
      />
      <router-link id="gardenlistlink" class="plantcardcontainer card" v-bind:to="{ name: 'virtualGardenListView' }">
        Explore Community Gardens
        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 512 512"><!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d="M320 0c-17.7 0-32 14.3-32 32s14.3 32 32 32h82.7L201.4 265.4c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0L448 109.3V192c0 17.7 14.3 32 32 32s32-14.3 32-32V32c0-17.7-14.3-32-32-32H320zM80 32C35.8 32 0 67.8 0 112V432c0 44.2 35.8 80 80 80H400c44.2 0 80-35.8 80-80V320c0-17.7-14.3-32-32-32s-32 14.3-32 32V432c0 8.8-7.2 16-16 16H80c-8.8 0-16-7.2-16-16V112c0-8.8 7.2-16 16-16H192c17.7 0 32-14.3 32-32s-14.3-32-32-32H80z"/></svg>
      </router-link>
    </section>

  </div>
</template>

<script>
import PlantGardenCard from "../components/PlantGardenCard.vue";
import PlantService from "../services/PlantService";
export default {
  components: { PlantGardenCard },
  name: "VirtualGardenView",
  data() {
    return {
      myPlants: [],
      name: "",
    };
  },
  computed: {
    isMyGarden() {
      const isMine = this.$route.params.user == this.$store.state.user.userId;
      return isMine;
    },
  },
  created() {
    //populate myPlants
    PlantService.listGardenPlants(this.$route.params.user).then(
      (response) => (this.myPlants = response.data)
    );
    PlantService.getAllGardens().then(
      (response) =>
        (this.name = response.data.find(
          (e) => e.userId == this.$route.params.user
        )["firstName"])
    );
  },
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Roboto:wght@100;400&family=Zen+Tokyo+Zoo&display=swap");
@import url("https://fonts.googleapis.com/css2?family=Roboto:wght@100;400&family=Zen+Loop:ital@1&family=Zen+Tokyo+Zoo&display=swap");

#gardencontainer{
  height:85%;
  
}
#gardentitle {
  font-family: "Zen Loop";
  font-size: 20pt;
  margin: 1px;
  margin-bottom: 5px;
  text-align: center;
}
#gardenheadline {
  display: block;
  text-align: center;
  margin: auto;
}
.my-virtual-garden-view{
  height: 100vh;
}

</style>