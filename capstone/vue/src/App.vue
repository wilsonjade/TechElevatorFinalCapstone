<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'plantDetail', params:{plantId:1} }">Plant detail id1</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'myStuffView', params:{user: 'id'} }">My Stuff </router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'virtualGardenView', params:{user: 'id'} }">My Virtual Garden </router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'searchView'}">Search Plants </router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{name: 'eventsView'}">Events</router-link>&nbsp;|&nbsp;      
      <router-link v-bind:to="{ name: 'sellersView' }">Sellers</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      <router-link v-bind:to="{ name: 'login' }" v-else>Login</router-link>&nbsp;|&nbsp;  

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
    this.$store.commit("LOAD_SELLERS");
  }
}
</script>




<style>
body {
  background-color: #7dd87d;
  color: #41304d;
  font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; 
}

a, button {
  background-color: #4c9173;
  color: #f6f7e8;
  border-radius: 8px;
  padding: 4px 6px;
  border: 2px solid #266147;
}

.card {
  background-color: #4c9173;
  color: #f6f7e8;
  border-radius: 8px;
  padding: 4px 6px;
  margin: 12px;
  border: 2px solid #266147;
}

a:hover, button:hover {
  font-weight: bold;
  color: #da98cc; 
  font-size: 1.1rem; 
}

section.container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

#nav {
  display: flex;
  justify-content: space-around;
}

.off-white { 
	background: #f6f7e8; 
}

.light-green { 
	background: #7dd87d; 
}
	
.medium-green { 
	background: #4c9173; 
}

.dark-green { 
	background: #266147; 
}

.dark-purple { 
	background: #41304d; 
}

.medium-purple { 
	background: #5b446a; 
}

.light-purple { 
	background: #da98cc; 
}
</style>