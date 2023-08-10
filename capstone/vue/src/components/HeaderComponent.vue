<template>
  <header id="header">
    <h1>HeaderComponent.vue</h1>

    <div class="login-out">
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        >Logout</router-link>
      <router-link v-bind:to="{ name: 'login' }" v-else>Login</router-link>
    </div>
  </header>
</template>

<script>
export default {};
</script>

<style>
</style>