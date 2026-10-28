<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes" encoding="utf-8"/>
  <!-- Replace root node name Menus with MenuItems and call MenuListing for its children-->
  <xsl:template match="/Menus">
    <MenuItems>
      <xsl:call-template name="MenuListing" />
    </MenuItems>
  </xsl:template>
  <!-- Allow for recursive child nodeprocessing -->
  <xsl:template name="MenuListing">
    <xsl:apply-templates select="Menu" />
  </xsl:template>
  <xsl:template match="Menu">
    <MenuItem>
      <!-- Convert Menu child elements to MenuItem attributes -->
      <xsl:attribute name="Text">
        <xsl:value-of select="NAME_PERSIAN"/>
      </xsl:attribute>
      <xsl:attribute name="ToolTip">
        <xsl:value-of select="NAME_PERSIAN"/>
      </xsl:attribute>
      <xsl:attribute name="NavigateUrl">
        <xsl:value-of select="MENU_LINK_PERSIAN"/>
      </xsl:attribute>
      <xsl:attribute name="EnableMenu">
        <xsl:if test="LINK_ACTIVE=1">
          <xsl:text>True</xsl:text>
        </xsl:if>
        <xsl:if test="LINK_ACTIVE=0">
          <xsl:text>False</xsl:text>
        </xsl:if>
      </xsl:attribute>
      <xsl:attribute name="MenuImage">
        <xsl:if test="MENU_ICON_LINK != ''">
          <xsl:text>~/</xsl:text>
          <xsl:value-of select="MENU_ICON_LINK"/>
        </xsl:if>
      </xsl:attribute>
      <!-- Recursively call MenuListing forchild menu nodes -->
      <xsl:if test="count(Menu) >0">
        <xsl:call-template name="MenuListing" />
      </xsl:if>
    </MenuItem>
  </xsl:template>
</xsl:stylesheet>
