<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
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