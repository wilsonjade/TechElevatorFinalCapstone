<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token != ''">Login</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'plantDetail', params:{plantId:1} }">Plant detail id1</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'myStuffView', params:{user: 'id'} }">My Stuff </router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'virtualGardenView', params:{user: 'id'} }">My Virtual Garden </router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'searchView'}">Search Plants </router-link>&nbsp;|&nbsp;

    </div>
    <router-view />
  </div>
</template>


<script>

export default {
  name: "App",
  components: {},
  data() {
    return {};
  },
  methods: {},

  created () {
    this.$store.commit("LOAD_PLANTS");
  }
}
</script>




<style>
section.container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}
</style>