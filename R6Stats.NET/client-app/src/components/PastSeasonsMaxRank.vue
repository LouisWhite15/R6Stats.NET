<template>
<div id="pastSeasonsMaxRank">
  <b-card
      title="Past Seasons Max Rank">
      <b-row v-for="item in seasonsData" :key="item" class="mx-auto">
          <b-col class="h6 my-auto">{{item.seasonName}}</b-col>
          <b-col class="my-auto mx-auto">
            <img :src="require('../assets/ranks/hd-rank' + item.maxRank + '.svg')" :alt="item.maxRankName + ' logo'" width="50" height="50">
            <p v-if="item.maxMmr !== null">{{item.maxMmr}}</p><p v-if="item.maxMmr === null">Unranked</p>
          </b-col>
    </b-row>
  </b-card>
</div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class PastSeasonsMaxRank extends Vue {
  @Prop() data:any;

  get seasonsData() {
    return Object.values(this.data.seasons).reverse();
  }
}
</script>

<style lang="scss">
.title{
  font-weight: bold;
  padding-top: 10px;
}

.data{
  padding-bottom: 10px;
}
</style>