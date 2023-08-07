<template>
  <section class="plant">
      
      <p>Id: {{plant.plantId}}</p>
      <p>Kingdom: {{plant.kingdom}}</p>
      <p>Species: {{plant.species}}</p>
      <p>Description: {{plant.description}}</p>


  </section>
</template>

<script>
export default {
    name: "plant",
    props: ["plant"],
}
</script>

<style>

</style>