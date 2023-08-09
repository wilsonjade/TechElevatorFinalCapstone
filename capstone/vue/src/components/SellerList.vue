<template>
  <section class="sellerList">
    <seller-detail v-for="seller in sellers" v-bind:key="seller.seller_id" v-bind:item="seller" /> 
    
      
  </section>
</template>

<script>
import SellerDetail from './SellerDetail.vue'


export default {

components: SellerDetail

}
</script>

<style>

</style>