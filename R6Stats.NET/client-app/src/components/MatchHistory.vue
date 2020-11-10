<template>
<div id="matchHistory">
  <b-card
    title="Match History">
    <b-container v-for="item in matchHistory" :key="item" class="mx-auto">
        <b-row class="bg-light title">
        <b-col style="font-size: 20px">{{item.date}}</b-col>
        </b-row>
        <b-row class="bg-light title">
        <b-col>MATCHES</b-col>
        <b-col>WINS</b-col>
        <b-col>LOSSES</b-col>
        </b-row>
        <b-row class="bg-light data">
        <b-col>{{item.rankedMatches}}</b-col>
        <b-col>{{item.rankedWins}}</b-col>
        <b-col>{{item.rankedLosses}}</b-col>
        </b-row>
        <b-row class="bg-light title">
        <b-col>KILLS</b-col>
        <b-col>DEATHS</b-col>
        <b-col>K/D</b-col>
        <b-col>HEADSHOT %</b-col>
        </b-row>
        <b-row class="bg-light data">
        <b-col>{{item.rankedKills}}</b-col>
        <b-col>{{item.rankedDeaths}}</b-col>
        <b-col>{{item.rankedKd}}</b-col>
        <b-col>{{item.headshotAccuracy}}</b-col>
        </b-row>
        <b-row class="bg-light title">
        <b-col>MMR CHANGE</b-col>
        </b-row>
        <b-row class="bg-light data">
        <b-col><p style="color: green" v-if="item.asiaMmrChange > 0">+{{item.asiaMmrChange}}</p><p style="color: red" v-if="item.asiaMmrChange < 0">{{item.asiaMmrChange}}</p><p v-if="item.asiaMmrChange == 0">{{item.asiaMmrChange}}</p></b-col>
        </b-row>
        <br>
    </b-container>
  </b-card>
</div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class MatchHistory extends Vue {
  @Prop() data:any;

  get matchHistory() {
    return Object.values(this.data.matchHistory).slice(0, 5);
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