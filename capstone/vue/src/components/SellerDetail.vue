<template>
  <section class="seller-detail card">
    <p class="card-header">Retailer</p>
    <h2>{{ item.sellerName }}</h2>
    <p>{{ item.sellerType }}</p>
    <p>{{ item.address1 }}</p>
    <p>{{ item.address2 }}</p>
    <p>{{ item.city }}, {{item.state}} {{ item.zip }}</p>
    <p>{{ item.website }}</p>

      <button><router-link v-bind:to="{name: 'ratingsBySeller', params: {sellerId: item.sellerId}}">See Ratings</router-link></button>
      
      <button><router-link v-bind:to="{name: 'ratingsAdmin', params: {sellerId: item.sellerId }}">Rate this Seller</router-link></button>

    <!-- WHY DOESN'T SELLER DETAIL KNOW USER IS ADMIN?? SELLER LIST KNOWS :( -->
    <button
      v-if="isAdmin"
      v-on:click="
        $router.push({ name: 'sellerAdmin', params: { sellerId: item.sellerId } })
      "
    >
      Edit Seller
    </button>
    <button v-if="isAdmin" v-on:click="deleteThisSeller()">
      Delete Seller
    </button>
  </section>
</template>

<script>
import sellerService from '../services/SellerService.js'

export default {
  components: {},
  name: "sellerDetail",
  props: ["item"],
  data() {
    return {
      isAdmin: false,
      seller: {},
    };
  },
  methods: {
    deleteThisSeller() {
      let wasSuccess = false;
      let errorMsg;
      sellerService
        .deleteSeller(this.item.sellerId)
        .then((response) => {
          wasSuccess = response.status == 200;
          alert(
            wasSuccess
              ? "Seller Deleted"
              : "Seller deletion unsuccessful, please try again"
          );
          this.$router.go(0); //refresh view
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            errorMsg = `Error deleting seller: ${error.response.status}`;
            alert(errorMsg);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            errorMsg = "Error deleting seller: unable to communicate to server";
            alert(errorMsg);
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            errorMsg = "Error deleting seller: error making request";
            alert(errorMsg);
          }
        });
    },
    created() {
      this.isAdmin = this.$store.state.user.role == "admin";
    },
  },
  created(){
    this.isAdmin = this.$store.state.user.role == 'admin';
  },
};
</script>

<style scoped>
.card {
  width: 90%;
  margin: 1rem auto;
}
</style>