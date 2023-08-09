<template>
  <section class="seller-detail">





  </section>
</template>

<script>


export default {
    name: "sellerDetail",
    props: ["item"],
    data() {
      return {
        isAdmin: false,
        sellers: [],
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