<template>
<<<<<<< HEAD
  <section>
    <p>Below, you will see a list of seller cards</p>
    <seller-detail v-for="seller in sellers" v-bind:key="seller.id" v-bind:item="seller" />
=======
  <section class="sellerList">
    <seller-detail v-for="seller in sellers" v-bind:key="seller.seller_id" v-bind:item="seller" /> 
    
      
>>>>>>> a11ab27fed5a31ee2bcde1a0831e2032dccf2517
  </section>
</template>

<script>
<<<<<<< HEAD
import SellerDetail from './SellerDetail.vue';

export default {
  components: { SellerDetail },
  data() {
    return {
      sellers: [],
    }
  },
  methods: {},
  };
=======
import SellerDetail from './SellerDetail.vue'


export default {

components: SellerDetail

}
>>>>>>> a11ab27fed5a31ee2bcde1a0831e2032dccf2517
</script>

<style>
</style>