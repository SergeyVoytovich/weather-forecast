<template>
  <div>
    <div v-for="item of items" v-bind:key="item">
      <Item v-bind:city="item"/>
    </div>
  </div>
</template>

<script>
import Item from "@/components/Item.vue";

export default {
  "name": "List",
  components: {Item},
  props: {
    items: [],
    revers: Boolean,
  }
}
</script>

<style scoped>

</style>