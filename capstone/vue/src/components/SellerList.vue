<template>
  <section>
    <h1>SellerList.vue:</h1>
    <seller-detail
      v-for="seller in sellers"
      v-bind:key="seller.id"
      v-bind:item="seller"
    />


    <router-link v-bind:to="{name: 'SellerAdmin'}">Add New Seller</router-link>

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
    };
  },
  methods: {},
  computed: {
    sellers() {
      return this.$store.state.sellers;
    }
  },
  created() {
    this.isAdmin = this.$store.state.user.role == "admin";
  },
};
</script>

<style>
</style>