<template>
  <div>
    <div v-for="item of items" v-bind:key="item">
      {{ item.name }}
    </div>
  </div>
</template>

<script>
export default {
  "name": "List",
  props: {
    items: [],
    revers: Boolean,
  }
}
</script>

<style scoped>

</style>