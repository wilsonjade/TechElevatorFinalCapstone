<template>
<div v-bind:class="classes">
    <div v-for="alert in alerts" v-bind:key="alert" class="alert">This is an alert {{alert}}</div>

</div>
  
</template>

<script>
export default {
    data(){
        return {
            alerts: ['alert1','alert2','alert3']
        }
    },
    name: "NotificationDisplay"
    ,
    computed: {
        classes(){
            return "alertcontainer show"
        }
    }
}
</script>

<style>
.show{
    display: flex;
}
.hide{
    display: none;
}
.alertcontainer{
    
    z-index: 5;
    position: absolute;
    top: 20%;
    left: 15%;
    
    flex-direction: row;
    justify-content: flex-start; 
    flex-wrap: wrap;
    border-style: solid;
    padding:5px;
    box-shadow: 5px 10px darkslategray;
    border-radius: 30px;
    background-color: steelblue;
    
}
.alert{
    min-width: 51%;
    margin-top: 5%;
    margin-bottom: 5%;
    border-style: solid;
    padding:5px;
    box-shadow: 2px 2px slategrey;
    border-radius: 10px;
    background-color: springgreen;
}
</style>