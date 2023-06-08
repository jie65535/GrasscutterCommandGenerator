namespace GrasscutterTools.Pages
{
    partial class PageTools
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnUpdateResources = new System.Windows.Forms.Button();
            this.BtnConvertCutScene = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnUpdateResources
            // 
            this.BtnUpdateResources.Location = new System.Drawing.Point(3, 3);
            this.BtnUpdateResources.Name = "BtnUpdateResources";
            this.BtnUpdateResources.Size = new System.Drawing.Size(100, 30);
            this.BtnUpdateResources.TabIndex = 0;
            this.BtnUpdateResources.Text = "Update res";
            this.BtnUpdateResources.UseVisualStyleBackColor = true;
            this.BtnUpdateResources.Click += new System.EventHandler(this.BtnUpdateResources_Click);
            // 
            // BtnConvertCutScene
            // 
            this.BtnConvertCutScene.Location = new System.Drawing.Point(109, 3);
            this.BtnConvertCutScene.Name = "BtnConvertCutScene";
            this.BtnConvertCutScene.Size = new System.Drawing.Size(150, 30);
            this.BtnConvertCutScene.TabIndex = 0;
            this.BtnConvertCutScene.Text = "Convert Cutscene";
            this.BtnConvertCutScene.UseVisualStyleBackColor = true;
            this.BtnConvertCutScene.Click += new System.EventHandler(this.BtnConvertCutScene_Click);
            // 
            // PageTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnConvertCutScene);
            this.Controls.Add(this.BtnUpdateResources);
            this.Name = "PageTools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnUpdateResources;
        private System.Windows.Forms.Button BtnConvertCutScene;
    }
}
