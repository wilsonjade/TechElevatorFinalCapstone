<template>
  <section>
    <p>Below, you will see a list of seller cards</p>
    <seller-detail v-for="seller in sellers" v-bind:key="seller.id" v-bind:item="seller" />
  </section>
</template>

<script>
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
</script>

<style>
</style>