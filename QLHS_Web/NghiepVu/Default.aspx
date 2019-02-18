<%@ Page Language="C#" %> 
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
 
<script runat="server">

    protected void history_Change(object sender, DirectEventArgs e)
    {
        try
        {
            string url = e.ExtraParams["url"].ToString();
            LoadPage(this.GetUrl(url));
        }
        catch (Exception ex)
        {
            
        }
    }
    protected string GetUrl(string url)
    {
        string retVal = string.Empty;
        string[] urlPart = url.Split('#');
        if (urlPart != null && urlPart.Length > 1 && !string.IsNullOrEmpty(urlPart[1]))
        {
            retVal = urlPart[1];
        }
        return retVal;
    }
    protected void FirstLoadContent_Render(object sender, DirectEventArgs e)
    {
        try
        {
            string url = e.ExtraParams["url"].ToString();
            LoadPage(this.GetUrl(url));
        }
        catch (Exception ex)
        {
            
        }
    }
    protected void LoadPage(string url)
    {        
        LoadConfig loadConfig = new LoadConfig();
        loadConfig.Mode = LoadMode.IFrame;
        loadConfig.ShowMask = true;
        loadConfig.Url = url;
        this.pnlContent.LoadContent(loadConfig);
    }
</script>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">    
        <ext:ResourceManager ID="resourceManager" runat="server" DirectMethodNamespace="Shell" />       
        <ext:History ID="history" runat="server">
            <DirectEvents>                                
                <Change OnEvent="history_Change">
                    <EventMask ShowMask="true" />           
                    <ExtraParams>
                        <ext:Parameter Name="url" Value="window.location.hash" Mode="Raw" />
                    </ExtraParams>
                </Change>            
            </DirectEvents>                    
        </ext:History>          
        <ext:Viewport ID="viewPort" runat="server" Layout="border">
            <Items>            
                <ext:TreePanel 
                    ID="TreePanel1"
                    runat="server"  
                    EnableDD="false"         
                    RootVisible="false"                
                    Region="West"                       
                    Width="200"                                 
                    ContainerScroll="true">
                    <Listeners>                
                        <Click Handler="if (!Ext.isEmpty(node.attributes.href)) { e.stopEvent(); window.location.hash = node.attributes.href; }" />              
                    </Listeners>                      
                    <Root>
                        <ext:TreeNode Text="Pages" Expanded="true">
                            <Nodes>
                                <ext:TreeNode Text="Sfera" Href="http://www.sfera.sk/sk.aspx"  />
                                <ext:TreeNode Text="Seminare" Href="http://www.seminare.sfera.sk/sk.aspx"  />
                                <ext:TreeNode Text="Energoforum" Href="http://www.energoforum.sk/sk"  />
                                <ext:TreeNode Text="External Color Picker" Href="http://www.colorpicker.com/"  />
                            </Nodes>
                        </ext:TreeNode>
                    </Root>                                               
                </ext:TreePanel>
                <ext:Panel ID="pnlContent" runat="server" Region="Center">                                                        
                    <DirectEvents>                        
                        <Render OnEvent="FirstLoadContent_Render">
                            <EventMask ShowMask="true" />                                                                                                                       
                            <ExtraParams>
                                <ext:Parameter Name="url" Value="window.location.hash" Mode="Raw" />
                            </ExtraParams>
                        </Render>
                    </DirectEvents>                                                              
                </ext:Panel>    
            </Items>
        </ext:Viewport>    
    </form>
    <script type="text/javascript">
        /*
        Ext.onReady(function () {
            pnlContent.loadIFrame = function (config) {
                var url = config.url; if (config.nocache === true) { url = url + ((url.indexOf("?") > -1) ? "&" : "?") + new Date().getTime(); }
                if (config.params) {
                    var params = {}, key; for (key in config.params) { var ov = config.params[key]; if (typeof ov === "function") { params[key] = ov.call(this); } else { params[key] = ov; } }
                    params = Ext.urlEncode(params); url = url + ((url.indexOf("?") > -1) ? "&" : "?") + params;
                }
                if (Ext.isEmpty(this.iframe)) {
                    var iframeObj = { tag: "iframe", id: this.id + "_IFrame", name: this.id + "_IFrame", cls: config.cls || "", src: url, frameborder: 0 }, layout = this.getLayout(); if (layout && layout.resizeTask && layout.resizeTask.cancel) { layout.resizeTask.cancel(); }
                    if (!this.layout || this.layout.type !== "fit") { layout = new Ext.Container.LAYOUTS.fit({}); this.setLayout(layout); }
                    this.removeAll(true); var p = this, iframeCt = new Ext.Container({
                        autoEl: iframeObj, listeners: {
                            render: function () {
                                p.iframe = this.el; if (config.monitorComplete) { p.startIframeMonitoring(); } else { this.el.on("load", p.afterLoad, p); }
                                p.fireEvent("beforeupdate", p, { url: url, iframe: this.el }); p.beforeIFrameLoad(config);
                            }
                        }
                    }); this.add(iframeCt); this.doLayout();
                } else { 
                    this.iframe.dom.src = String.format("java{0}", "script:false"); 
                        this.fireEvent("beforeupdate", this, { url: this.iframe.dom.src, iframe: this.iframe }); 
                        window.frames[this.iframe.id].location.replace(url); // here for example: if (config.iFrameLoadMode && config.iFrameLoadMode === "noHistory") { window.frames[this.iframe.id].location.replace(url); } else { this.iframe.dom.src=url; }
                        this.beforeIFrameLoad(config); 
                }
                if (Ext.isIE6 && !this.destroyIframeOnUnload) { this.destroyIframeOnUnload = true; if (window.addEventListener) { window.addEventListener("unload", this.destroy.createDelegate(this), false); } else if (window.attachEvent) { window.attachEvent("onunload", this.destroy.createDelegate(this)); } }
                return this;
            }
        });        
    </script>
</body>
</html>