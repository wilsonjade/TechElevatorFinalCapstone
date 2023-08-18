<template>
  <section>
    <aside>
      <nav-bar />
    </aside>
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
  components: { NavBar, HeaderComponent, FooterComponent,  },
  data() {
    return {};
  },
  methods: {},

  created() {
    this.$store.commit("LOAD_PLANTS");
    this.$store.commit("LOAD_SELLERS");
    this.$store.commit("LOAD_FUTURE_EVENTS");
    this.$store.commit("LOAD_COMMUNICATIONS");
    this.$store.commit("LOAD_FUTURE_COMMUNICATIONS");
    this.$store.commit("LOAD_TASKS");
  },
};
</script>




<style>
:root {
  font-size: 16px;
  font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande",
    "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
}

body {
  background: url(assets/background-image.jpg) no-repeat center center fixed;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;

  margin: 0;
  padding: 0;

  color: #22311d;
}

a {
  color: #f6f7e8;
  text-decoration: none;
}

img {
  max-width: 100%;
  border-radius: 12px;
}

.view {
  padding-top: 15px;
}

.grid-container {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 1rem;
}

.flex-container {
  display: flex;
  flex-direction: row;
  justify-content: center;
  flex-wrap: wrap;
}

.card {
  background-color: #85b488b7;
  color: #22311d;
  border-radius: 12px;
  padding: 4px 12px 8px 12px;
  margin: .5rem .5rem 1.2rem .5rem;
  border: 2px solid #22311d;
  box-shadow: 8px 8px 6px 1px #22311d;
}

.card-header {
  background-color: #446047;
  color: #f6f7e8;
  text-align: center;
  border-radius: 12px;
  margin-top: 4px;
}

button {
  background-color: #77a370;
  color: #f6f7e8;
  border-radius: 16px;
  padding: 6px 12px;
  margin: .5rem;
  border: 2px solid #22311d;
  font-weight: bold;
}

button:hover {
  font-weight: bold;
}

section.container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

#main {
  margin-left: 5rem;
  margin-bottom: 10rem;
  margin-top: 5rem;
  padding: 1rem;
  margin-top: 50px;
  top: 5rem;
}

#header {
  position: fixed;
  padding-top: 1rem;
  padding-bottom: 1rem;
  padding-right: 10rem;
  width: 100%;
  top: 0;
  left: 0;
  height: 35px;
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: #f0b45b75;
  font-size: 2rem;
  font-family: fantasy;
  color: #567a49;

}

#header:onscroll {
  display: hide;
}

#footer {
  position: fixed;
  margin-left: 5rem;
  padding: 1rem 1.5rem 1rem 1.5rem;
  width: 100%;
  bottom: 0;
  left: 0;
  height: 1rem;
  background-color: #446047;
  color: #f6f7e8;
  width: 100%;
  text-align: right;
}
</style>
