<template>
  <section class="plantCard card flex-container">
    <h2 v-if="isHomePage" class="card-header">View our Plant of the day!</h2>
    <h1 class="headline">Common name: {{ plant.commonName }}</h1>
    <div class="card grid-container">
      <div grid-left>
        <p>Kingdom: {{ plant.kingdom }}</p>
        <p>Order: {{ plant.order }}</p>
        <p>Family: {{ plant.family }}</p>
        <p>Subfamily: {{ plant.subfamily }}</p>
        <p>Genus: {{ plant.genus }}</p>
        <p>Species: {{ plant.species }}</p>
        <p>Description: {{ plant.description }}</p>
      </div>

      <section class="flex-container grid-right">
        <img
          id="plant-image"
          v-bind:src="plant.imgUrl"
          alt="plant image"
        />
      </section>
    </div>


    <section>
      <button v-on:click="addToGarden()">Add to My Virtual Garden</button>
      <button>
        <router-link v-bind:to="{ name: 'sellersByPlant' }"
          >Find Retailers</router-link
        >
      </button>
    </section>
  </section>
</template>

<script>
import plantService from "../services/PlantService.js";

export default {
  name: "plant",

  methods: {
    getThisPlant() {
      plantService.getPlantById(this.$route.params.plantId).then((response) => {
        console.log(response);
        this.plant = response.data;
      });
    },
    addToGarden() {
      plantService
        .addToGarden({
          plantId: this.plant.plantId,
          userId: this.$store.state.user.userId,
        })
        .then((response) => {
          if (response.status == 200) {
            this.$router.push({
              name: "virtualGardenView",
              params: { user: this.$store.state.user.userId },
            });
          }
        })
        .catch((error) => {
          console.log(error.message);
          this.$router.push({
            name: "virtualGardenView",
            params: { user: this.$store.state.user.userId },
          });
        });
    },
  },

  data() {
    return {
      plant: {},
    };
  },

  created() {
    this.getThisPlant();

    this.isAdmin = this.$store.state.user.role == "admin";
  },
};
</script>

<style scoped>
.grid-container {
  grid-template-columns: 1fr 1fr;
  grid-template-areas: "grid-left grid-right";
}

.grid-left {
  grid-area: grid-left;
}

.grid-right {
  grid-area: grid-right;
  margin: auto;
}

.plantCard {
  margin: 1rem auto;
  flex-direction: column;
  max-width: 900px;
}

@media (min-width: 900px) {
  /* CSS */
}
</style>