<template>
  <section class="seller-detail">
    <h1>SellerDetail.vue</h1>
    <h1>{{item.seller_name}}</h1>
    <p>{{item.seller_type}}</p>
    <p>{{item.address1}}</p>
    <p>{{item.address2}}</p>
    <p>{{item.city}}</p>
    <p>{{item.state}}</p>
    <p>{{item.zip}}</p>
    <p>{{item.website}}</p>
  </section>
</template>

<script>



export default {
    components: {  },
    name: "sellerDetail",
    props: ["item"],
    data() {
      return {
        isAdmin: false,
        seller: {},
      };
    },
    methods: {},
    created() {
      this.isAdmin = this.$store.state.user.role == 'admin';


    },

}
</script>

<style>

</style>