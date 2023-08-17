<template>
  <div class="home grid-container">
    <div class="grid-left">
  <section class="plantCard card flex-container">
    <div>
    <h2 class="card-header">View our Plant of the day!</h2>
    <h3 class="headline">Common name: {{ plant.commonName }}</h3>
    </div>
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
          alt="a generic plant image"
        />
      </section>
    </div>
    <section>
      <p>
        <router-link v-if="isAdmin" :to="{ name: 'taskAdmin' }"
          >Edit and add task.</router-link
        >
      </p>
    </section>
    <section>
      <p>
        <router-link v-if="isAdmin" :to="{ name: 'taskAdminDelete' }"
          >Delete task.</router-link
        >
      </p>
    </section>

    <section>
      <button v-on:click="addToGarden()">Add to My Virtual Garden</button>
      <button>
        <router-link v-bind:to="{ name: 'sellersByPlant' }"
          >Find Retailers</router-link
        >
      </button>
    </section>
  </section>
    </div>

    <div class="grid-right">
      <notification-display />
    </div>
  </div>
</template>

<script>
import NotificationDisplay from "../components/NotificationDisplay.vue";
import plantService from "../services/PlantService.js";

export default {
  components: { NotificationDisplay,  },
  name: "home",
  data() {
    return {
      isHomePage: true,
      plant: {}
    };
  },
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
  computed: {
    plants() {
      return this.$store.state.plants;
    },
  },
  created() {
      plantService.getPlantById(Math.floor(Math.random() * 14))
      .then((response) => {
        console.log(response);
        this.plant = response.data;
      });
  }
};
</script>

<style scoped>
.grid-container {
  grid-template-columns: 1fr 1fr;
  grid-template-areas: "grid-left grid-right";
}

.grid-left {
  grid-area: grid-left;
  padding-top: 1rem;
}

.grid-right {
  grid-area: grid-right;
  margin: auto;
}

.card-header {
  padding: 8px 12px;
  min-width: 400px;
  text-align: center;
}
</style>
