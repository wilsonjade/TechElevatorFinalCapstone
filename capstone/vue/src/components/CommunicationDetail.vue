<template>
  <section class="communication-detail card">
    <h1>Title: {{ item.title }}</h1>
    <p>Type: {{ item.type }}</p>
    <p>Description: {{ item.description }}</p>

    <button>Join this {{item.type}}</button>



  </section>
</template>

<script>
export default {
    name: "communicationsDetail",
    props: ["item"],

}
</script>

<style>

</style>