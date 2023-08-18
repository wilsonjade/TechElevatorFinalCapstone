<template>
  <section id="seller-list" class="grid-container">
    <button v-if="isAdmin" class="add-button">
      <router-link v-if="isAdmin" v-bind:to="{ name: 'SellerAdmin' }"
        >Add New Seller
        <svg
          xmlns="http://www.w3.org/2000/svg"
          height="1em"
          viewBox="0 0 512 512"
        >
          <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
          <path
            d="M320 0c-17.7 0-32 14.3-32 32s14.3 32 32 32h82.7L201.4 265.4c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0L448 109.3V192c0 17.7 14.3 32 32 32s32-14.3 32-32V32c0-17.7-14.3-32-32-32H320zM80 32C35.8 32 0 67.8 0 112V432c0 44.2 35.8 80 80 80H400c44.2 0 80-35.8 80-80V320c0-17.7-14.3-32-32-32s-32 14.3-32 32V432c0 8.8-7.2 16-16 16H80c-8.8 0-16-7.2-16-16V112c0-8.8 7.2-16 16-16H192c17.7 0 32-14.3 32-32s-14.3-32-32-32H80z"
          />
        </svg>
      </router-link>
    </button>

    <seller-detail
      v-for="seller in filteredSellers"
      v-bind:key="seller.id"
      v-bind:item="seller"
    />
  </section>
</template>

<script>
import SellerService from "../services/SellerService";
import SellerDetail from "./SellerDetail.vue";

export default {
  name: "listSellers",
  props: ["item"],
  components: { SellerDetail },
  data() {
    return {
      isAdmin: false,
      filteredSellersByPlant: [],
    };
  },
  methods: {},
  computed: {
    sellers() {
      return this.$store.state.sellers;
    },
    filteredSellers() {
      if (this.filteredSellersByPlant.length > 0) {
        return this.$store.state.sellers.filter((seller) => {
          return this.filteredSellersByPlant.includes(seller.sellerId);
        });
      } else {
        return this.$store.state.sellers;
      }
    },
  },
  created() {
    this.isAdmin = this.$store.state.user.role == "admin";
    //call database for valid list of seller IDs
    if (this.$route.params.plantId) {
      SellerService.getSellersByPlantId(this.$route.params.plantId).then(
        (response) => {
          this.filteredSellersByPlant = response.data;
        }
      );
    }
  },
};
</script>

<style scoped>
#seller-list {
  margin: auto;
}

.grid-container {
  grid-template-columns: 1fr 1fr;
    grid-template-areas:
  "add-button add-button" 
  "card card" ;
  gap: 1rem;
}

svg {
  fill: #f6f7e8;
}


.add-button{  
  grid-area: add-button;
  width: 20vw;
  margin-top: 20px;
  background-color: #77a370;
  color: #f6f7e8;
  border-radius: 16px;
  padding: 6px 12px;
  margin: 1.5rem auto 0 auto;
  border: 2px solid #22311d;
  font-weight: bold;


}

.add-button {
  font-size: 20px;
}
</style>