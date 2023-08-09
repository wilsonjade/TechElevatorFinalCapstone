<template>
  <section class="seller-detail card">
    <h1>{{item.sellerName}}</h1>
    <p>{{item.sellerType}}</p>
    <p>{{item.address1}}</p>
    <p>{{item.address2}}</p>
    <p>{{item.city}}</p>
    <p>{{item.state}}</p>
    <p>{{item.zip}}</p>
    <p>{{item.website}}</p>

    <button>Edit Seller</button>
    <button>Delete Seller</button>
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