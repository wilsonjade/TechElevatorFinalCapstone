<template>
  <section>
    <router-link v-bind:to="{ name: 'SellerAdmin' }"
      >Add New Seller</router-link
    >

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

<style>
</style>