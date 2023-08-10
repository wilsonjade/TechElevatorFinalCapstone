<template>
  <section>
    <nav-bar />
    <section id="main">
      <header-component />
      <router-view />
      <footer-component />
    </section>
  </section>
</template>


<script>
import HeaderComponent from "./components/HeaderComponent.vue";
import NavBar from "./components/NavBar.vue";
import FooterComponent from "./components/FooterComponent.vue";

export default {
  name: "App",
  components: { NavBar, HeaderComponent, FooterComponent },
  data() {
    return {};
  },
  methods: {},

  created() {
    this.$store.commit("LOAD_PLANTS");
    this.$store.commit("LOAD_SELLERS");
    this.$store.commit("LOAD_RATINGS");
  },
};
</script>




<style>
:root {
  font-size: 16px;
}

body {
  background: url(assets/background-image.jpg) no-repeat center center fixed;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;

  margin: 0;
  padding: 0;

  color: #41304d;
  font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande",
    "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
}

.card {
  background-color: #4c9173a8;
  color: #f6f7e8;
  border-radius: 8px;
  padding: 4px 6px;
  margin: 12px;
  border: 2px solid #266147;
  max-width: 400px;
}

button {
  background-color: #4c9173;
  color: #f6f7e8;
  border-radius: 8px;
  padding: 4px 6px;
  border: 2px solid #266147;
}

button:hover {
  font-weight: bold;
  color: #da98cc;
}

section.container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

#nav {
  grid-area: nav-bar;
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 5rem;
  height: 100vh;
  position: fixed;
  background-color: #7dd87d9c;
  padding: 0;
  margin: 0;
}

.nav-item {
  padding: 5px 0 5px 0;
}

nav ul {  
  list-style: none;
}

.nav-item:last-child {
  margin-top: auto;
}

#main {
  margin-left: 5rem;
  margin-bottom: 5rem;
  margin-top: 5rem;
  padding: 1rem;
  margin-top: 50px;
  top: 5rem;
}

#header {
  grid-area: header;
  position: fixed;
  margin-left: 5rem;
  padding: 1rem;
  width: 100%;
  top: 0;
  left: 0;
  height: 35px;
  display: flex;
  justify-content: space-around;
  align-items: center; 
  background-color: #f0b45b75;
}

#footer {
  grid-area: footer;
  position: fixed;
  margin-left: 5rem;
  padding: 1rem;
  width: 100%;
  bottom: 0;
  left: 0;
  height: 35px;
  background-color: darkolivegreen;
  color: #f6f7e8;
  width: 100%;
  text-align: center;
}

img {
  width: 300px;
  border-radius: 100%;
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