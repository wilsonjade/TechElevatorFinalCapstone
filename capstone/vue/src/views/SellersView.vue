<template>
  <section>
    <h1>This is the SellersView</h1>
    <p>list of sellers here</p>
    <seller-detail v-for="seller in sellers" v-bind:key="seller.id" v-bind:item="seller"/>


  </section>
</template>

<script>
import SellerDetail from '../components/SellerDetail.vue'
import sellerService from '../services/SellerService.js'

export default {
    name: "sellerView",
    components: {SellerDetail},
    data() {
      return {
        sellers: {},
        isAdmin: false,
      }
    },
    methods: {
      getListSellers() {
        sellerService.listSellers()
        .then( response => this.sellers = response.data);
      },
      newSeller() {
        this.$router.push( {name: "sellerAdmin", params: {id: 0}} )
      },
    },
    created() {
      this.getListSellers();
      this.isAdmin = this.$store.state.user.role == 'admin';
    }

}
</script>

<style>

</style>