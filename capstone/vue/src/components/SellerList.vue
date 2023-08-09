<template>
  <section>
    <router-link v-bind:to="{ name: 'SellerAdmin' }"
      >Add New Seller</router-link>

    <seller-detail
      v-for="seller in sellers"
      v-bind:key="seller.id"
      v-bind:item="seller"
    />
  </section>
</template>

<script>
import SellerDetail from "./SellerDetail.vue";

export default {
  name: "listSellers",
  props: ["item"],
  components: { SellerDetail },
  data() {
    return {
      isAdmin: false,
      filteredSellers: [],
    };
  },
  methods: {},
  computed: {
    sellers() {
      return this.$store.state.sellers;
    },
    filiteredSellersByPlantId() {
      return this.$store.state.sellers.filter((seller) => {
        return this.filteredSellers.includes(seller.sellerId)
      });
    },
  },
  created() {
    this.isAdmin = this.$store.state.user.role == "admin";
    this.filteredSellers = this.$store.state.sellers;
  },
};
</script>

<style>
</style>