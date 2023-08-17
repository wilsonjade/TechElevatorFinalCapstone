<template>
  <section class="card">
    <h3>Welcome to the Search Page</h3>
    <h1>
      While here, you can search plants by common name, family, species, and
      genus.
    </h1>

    <form v-on:submit.prevent="searchPlantByCommonName()">
      <div class="searchbar">
        <div class="flex-container">
          <label>Common Name:</label>
          <input
            class="search-input"
            v-model="search.commonName"
            type="text"
            placeholder="Search plants by name.."
          />
        </div>

        <div class="flex-container">
          <label>Family:</label>
          <input
            class="search-input"
            v-model="search.family"
            type="text"
            placeholder="Search plants by family.."
          />
        </div>

        <div class="flex-container">
          <label>Species</label>
          <input
            class="search-input"
            v-model="search.species"
            type="text"
            placeholder="Search plants by species.."
          />
        </div>

        <div class="flex-container">
          <label>Genus:</label>
          <input
            class="search-input"
            v-model="search.genus"
            type="text"
            placeholder="Search plants by genus.."
          />
          <input class="button" type="submit" value="Search" />
        </div>
      </div>
    </form>

    <table class="table" v-if="!plants.length == 0">
      <thead>
        <th class="t-head">Common Name</th>
        <th>Family</th>
        <th>Genus</th>
        <th>Species</th>
        <th>Description</th>
        <th>View Details</th>
      </thead>
      <tbody>
        
        <tr v-for="plant in plants" v-bind:key="plant.id">
          
          <td>{{ plant.commonName }}</td>
          <td>{{ plant.family }}</td>
          <td>{{ plant.genus }}</td>
          <td>{{ plant.species }}</td>
          <td>{{ plant.description }}</td>
          <td>
            <button>
              <router-link
                v-bind:to="{
                  name: 'plantDetail',
                  params: { plantId: plant.plantId },
                }"
                >Details</router-link
              >
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </section>
</template>

<script>
import plantService from "../services/PlantService.js";

export default {
  name: "search",
  components: {},
  data() {
    return {
      search: { commonName: "", family: "", species: "", genus: "" },
      plants: [],
    };
  },
  methods: {
    searchPlantByCommonName() {
      plantService.getPlantByCommonName(this.search).then((response) => {
        console.log(response);
        this.plants = response.data;
      });
    },
  },
};
</script>






<style scoped>
.searchbar input[type="text"] {
  padding: 10px;
  border: 2px solid #22311d;
  border-radius: 10px;
  margin-top: 10px;
  margin-right: 30px;
  font-size: 20px;
}

.flex-container {
  flex-direction: column;
  align-items: space-between;
  widows: 500px;
}

.search-input {
  max-width: min-content;
  background-color: #f6f7e89a;
  }

.button {
  width: 10vw;
  margin-top: 20px;
  background-color: #77a370;
  color: #f6f7e8;
  border-radius: 16px;
  padding: 6px 12px;
  margin: 0.5rem;
  border: 2px solid #22311d;
  font-weight: bold;
}

.table {
  background-color: #f6f7e89a;
  color: black;
  border-radius: 16px;
  padding: 6px 12px;
  margin: 0.5rem;
  border: 2px solid #22311d;
}

table, th, td
{
 border-style: solid;
 border-color: rgb(1, 85, 36);
 border-width: .5px;
 border-radius: 16px;
 border-collapse: collapse;
 padding-left: 8px;
 padding-right: 8px;

}
</style>