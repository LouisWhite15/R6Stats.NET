<template>
  <div class="card-columns" >
    <div v-if="results.totalResults === 0">
      No results found.
    </div>
    <div class="card" v-for="item in results.playerResults" :key="item.playerId">
      <div class="card-body">
        <h5 class="card-title">{{item.playerName}}</h5>
        <p class="card-text" v-html="`Current MMR: ${item.currentMmr}<br>Current Rank: ${item.currentRank}`"></p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class Results extends Vue {
  @Prop() data:any;

  get results() {
    return this.data;
  }
}
</script>