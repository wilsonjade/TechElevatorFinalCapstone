<template>
  <div class="my-virual-garden view">
    <section class="header">
      <h1 id="gardentitle">{{ name }}'s Garden</h1>
    </section>    
    <section class="flex-container">
      <plant-garden-card
        v-for="plant in myPlants"
        v-bind:key="plant.plantId"
        v-bind:thisPlant="plant"
        v-bind:isMine="isMyGarden"
      />
      <router-link class="card" v-bind:to="{ name: 'virtualGardenListView' }">
        Explore Community Gardens
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


</style>