<template>
  <div id="gardenlistcontainer">
      <div class="gardenlistcard" v-for="garden in gardens" v-bind:key="garden.userId">
          {{garden.userId}}
          {{garden.userFirstName}}
      </div>

  </div>
</template>

<script>
export default {
    name: 'virtualGardenListView'
    ,
    data(){
        return {
            gardens: [
                {userId: 1,
                userFirstName: 'mitch',
                expertiseLevel: 2,
                region: 6,
                countOfPlants: 3,
                }
            ]
        }
    }
    ,
    created(){

    }
}
</script>

<style>

</style>