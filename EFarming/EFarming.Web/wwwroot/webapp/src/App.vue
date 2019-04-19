<template>
  <div class="layout">
    <Layout>
      <Sider ref="side1" hide-trigger collapsible :collapsed-width="78" v-model="isCollapsed">
        <Menu active-name="1" theme="light" width="auto" :class="menuitemClasses">
          <div class="logo">
            <img src="./assets/logo.png">
          </div>
          <MenuItem name="1" to="/">
            <Icon type="ios-navigate"></Icon>
            <span>首页</span>
          </MenuItem>
          <Submenu name="2">
            <template slot="title">
              <Icon type="ios-navigate"></Icon>系统管理
            </template>
            <MenuItem name="2-1">用户管理</MenuItem>
            <MenuItem name="2-2">角色管理</MenuItem>
            <MenuItem name="2-3">认证管理</MenuItem>
          </Submenu>
          <MenuItem name="3">
            <Icon type="ios-search"></Icon>
            <span>内容管理</span>
          </MenuItem>
          <MenuItem name="4">
            <Icon type="ios-settings"></Icon>
            <span>日志记录</span>
          </MenuItem>
        </Menu>
      </Sider>
      <Layout>
        <Header :style="{padding: 0}" class="layout-header-bar">
          <Icon
            @click.native="collapsedSider"
            :class="rotateIcon"
            :style="{margin: '20px',float:'left'}"
            type="md-menu"
            size="24"
          ></Icon>
          <Breadcrumb :style="{float:'left'}">
            当前位置：<BreadcrumbItem to="/">首页</BreadcrumbItem>
            <!-- <BreadcrumbItem to="/components/breadcrumb">Components</BreadcrumbItem>
            <BreadcrumbItem>Breadcrumb</BreadcrumbItem>-->
          </Breadcrumb>
          <Menu mode="horizontal" :theme="light" active-name="1" :style="{float:'right'}">
            <Submenu name="1">
              <template slot="title">
                <Icon type="ios-stats"/>统计分析
              </template>
              <MenuGroup title="使用">
                <MenuItem name="3-1">新增和启动</MenuItem>
                <MenuItem name="3-2">活跃分析</MenuItem>
                <MenuItem name="3-3">时段分析</MenuItem>
              </MenuGroup>
              <MenuGroup title="留存">
                <MenuItem name="3-4">用户留存</MenuItem>
                <MenuItem name="3-5">流失用户</MenuItem>
              </MenuGroup>
            </Submenu>
          </Menu>
        </Header>
        <Content :style="{margin: '5px', padding:'10px' ,background: '#fff', minHeight: '260px'}">
          <router-view/>
        </Content>
      </Layout>
    </Layout>
  </div>
</template>

<script>
export default {
  name: "App",
  data() {
    return {
      isCollapsed: false
    };
  },
  computed: {
    rotateIcon() {
      return ["menu-icon", this.isCollapsed ? "rotate-icon" : ""];
    },
    menuitemClasses() {
      return ["menu-item", this.isCollapsed ? "collapsed-menu" : ""];
    }
  },
  methods: {
    collapsedSider() {
      this.$refs.side1.toggleCollapse();
    }
  }
};
</script>

<style scoped>
.layout {
  border: 1px solid #d7dde4;
  background: #f5f7f9;
  position: relative;
  border-radius: 4px;
  overflow: hidden;
}
.layout-header-bar {
  background: #fff;
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
}
.layout-logo-left {
  width: 90%;
  height: 30px;
  background: #5b6270;
  border-radius: 3px;
  margin: 15px auto;
}
.menu-icon {
  transition: all 0.3s;
}
.rotate-icon {
  transform: rotate(-90deg);
}
.menu-item span {
  display: inline-block;
  overflow: hidden;
  width: 69px;
  text-overflow: ellipsis;
  white-space: nowrap;
  vertical-align: bottom;
  transition: width 0.2s ease 0.2s;
}
.menu-item i {
  transform: translateX(0px);
  transition: font-size 0.2s ease, transform 0.2s ease;
  vertical-align: middle;
  font-size: 16px;
}
.collapsed-menu span {
  width: 0px;
  transition: width 0.2s ease;
}
.collapsed-menu i {
  transform: translateX(5px);
  transition: font-size 0.2s ease 0.2s, transform 0.2s ease 0.2s;
  vertical-align: middle;
  font-size: 22px;
}
.ivu-layout-sider {
  background: #fff;
}

.logo {
  text-align: center;
  width: 100%;
  height: 64px;
  position: relative;
}

.logo img {
  /* width: 100%; */
  height: 100%;
  vertical-align: middle;
}

.ivu-menu-horizontal {
  height: 64px;
}

.ivu-menu-horizontal::after {
  display: none;
}
</style>
