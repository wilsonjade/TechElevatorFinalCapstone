<template>
  <nav id="nav">
    <ul>
      <li class="nav-item"><router-link v-bind:to="{ name: 'home' }">Home</router-link></li>
      <li class="nav-item">
        <router-link v-bind:to="{ name: 'plantDetail', params: { plantId: 1 } }"
          >Plant detail id1</router-link
        >
      </li>
      <li class="nav-item">
        <router-link v-bind:to="{ name: 'myStuffView', params: { user: 'id' } }"
          >My Stuff
        </router-link>
      </li>
      <li class="nav-item">
        <router-link
          v-bind:to="{ name: 'virtualGardenView', params: { user: 'id' } }"
          >My Virtual Garden
        </router-link>
      </li>
      <li class="nav-item">
        <router-link v-bind:to="{ name: 'searchView' }"
          >Search Plants
        </router-link>
      </li>
      <li class="nav-item">
        <router-link v-bind:to="{ name: 'eventsView' }">Events</router-link>
      </li>
      <li class="nav-item">
        <router-link v-bind:to="{ name: 'sellersView' }">Sellers</router-link>
      </li>
    </ul>
    <div class="login-out nav-item">
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
         class="nav-item">Logout</router-link
      >
      <router-link v-bind:to="{ name: 'login' }" v-else class="nav-item">Login</router-link>
    </div>
  </nav>
</template>

<script>
export default {
  name: "navBar",
};
</script>

<style>
</style>