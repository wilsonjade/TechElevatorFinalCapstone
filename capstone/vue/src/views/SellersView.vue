<template>
  <section>
    <h1>SellersView.vue</h1>
    <seller-list />

  </section>
</template>

<script>
import SellerList from '../components/SellerList.vue'
import sellerService from '../services/SellerService.js'

export default {
    name: "sellerView",
    components: {SellerList},
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